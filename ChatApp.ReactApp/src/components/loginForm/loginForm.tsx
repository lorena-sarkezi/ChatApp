import { useState } from "react";
import { RouteComponentProps, withRouter } from "react-router";

import { Form, Input, Button, Checkbox } from "antd";

import { ILogin } from "../../models/ILogin";
import axios from "axios";

interface LoginProps extends RouteComponentProps<any> {}

const LoginForm: React.FC<LoginProps> = (props) => {
  const [username, setUsername] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [remember, setRemember] = useState<boolean>(false);

  const onUsernameChanged = (val: string) => {
    console.log(val);
    setUsername(val);
  };

  const onPasswordChanged = (val: string) => {
    console.log(val);
    setPassword(val);
  };

  const onRememberChkChanged = (val: boolean) => {
    console.log(val);
    setRemember(val);
  };

  const onSubmit = async () => {
    console.log("Success - Sending data to Auth Controller");

    const data: ILogin = {
      username: username,
      password: password,
      rememberMe: remember,
    };

    try {
      let response = await axios.post<ILogin, string>(
        "/api/auth/authenticate",
        data
      );
      window.localStorage.setItem("bearer", response);

      props.history.push("/home");

      console.log(response);
    } catch (e) {
      console.error(e);
    }
  };

  return (
    <Form
      name="login-form"
      labelCol={{ span: 7 }}
      wrapperCol={{ span: 16 }}
      initialValues={{ remember: true }}
      onFinish={onSubmit}
      //onFinishFailed={onFail}
      autoComplete="off"
    >
      <Form.Item
        label="Username"
        name="username"
        rules={[{ required: true, message: "Please input your username!" }]}
      >
        <Input
          value={username}
          onChange={(e) => onUsernameChanged(e.target.value)}
        />
      </Form.Item>

      <Form.Item
        label="Password"
        name="password"
        rules={[{ required: true, message: "Please input your password!" }]}
      >
        <Input.Password
          value={password}
          onChange={(e) => onPasswordChanged(e.target.value)}
        />
      </Form.Item>

      <Form.Item
        name="remember"
        valuePropName="checked"
        wrapperCol={{ offset: 8, span: 16 }}
      >
        <Checkbox
          checked={remember}
          onChange={(e) => onRememberChkChanged(e.target.checked)}
        >
          Remember me
        </Checkbox>
      </Form.Item>

      <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
        <Button type="primary" htmlType="submit">
          Submit
        </Button>
      </Form.Item>
    </Form>
  );
};

export default withRouter(LoginForm);
