import { useState } from "react";
import { RouteComponentProps, withRouter } from "react-router";
import { Link } from 'react-router-dom';

import { Form, Input, Button, Checkbox } from "antd";
import { UserOutlined, LockOutlined } from '@ant-design/icons';
import GoogleLogin from "react-google-login";


import { ILogin } from "../../models/ILogin";
import axios from "axios";

interface LoginProps extends RouteComponentProps<any> { }

const LoginForm: React.FC<LoginProps> = (props) => {
    const [username, setUsername] = useState<string>("");
    const [password, setPassword] = useState<string>("");
    const [remember, setRemember] = useState<boolean>(false);

    const onGoogleLogin = (response) => {
        console.log(response)
    }

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
            // wrapperCol={{ span: 16 }}
            initialValues={{ remember: true }}
            onFinish={onSubmit}
            //onFinishFailed={onFail}
            autoComplete="off"
        >
            <Form.Item
                name="username"
                rules={[{ required: true, message: "Please input your username!" }]}
            >
                <Input
                    value={username}
                    placeholder="Username or E-Mail"
                    prefix={<UserOutlined />}
                    onChange={(e) => onUsernameChanged(e.target.value)}
                />
            </Form.Item>

            <Form.Item
                name="password"
                rules={[{ required: true, message: "Please input your password!" }]}
            >
                <Input.Password
                    value={password}
                    placeholder="Password"
                    prefix={<LockOutlined />}
                    onChange={(e) => onPasswordChanged(e.target.value)}
                />
            </Form.Item>

            <Form.Item
                name="remember"
                valuePropName="checked"
                
            >
                <Checkbox
                    checked={remember}
                    onChange={(e) => onRememberChkChanged(e.target.checked)}
                >
                    Remember me
                </Checkbox>
            </Form.Item>

            <div>
                <span>
                    Dont have an account? <Link to="/register">Register!</Link>
                </span>
            </div>

            <Button type="primary" htmlType="submit" className="submit-btn button-separation">
                    Submit
            </Button>

            <div className="horizontal-center-flex">
                <GoogleLogin
                    clientId="936279636917-0tpgpvtroj7hhk8cc6cbuqvcjvsrsl7p.apps.googleusercontent.com"
                    onSuccess={onGoogleLogin}
                    onFailure={onGoogleLogin}
                    className="submit-btn button-separation horizontal-center-flex"
                    />
            </div>


        </Form>
    );
};

export default withRouter(LoginForm);
