import { Row, Card } from "antd";

import LoginForm from "../../components/loginForm";

export const Login = () => {

  return (
    <Row>
      <Card title="Login" className="horizontal_center">
          <LoginForm />
      </Card>
    </Row>
  );
};
