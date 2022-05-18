import { Row, Card } from "antd";

import LoginForm from "../../components/loginForm";

import '../../index.css';

export const Login = () => {
    

    return (
        <Row className="container-centered">
            <Card title="Login" style={{width:"350px"}}>
                <LoginForm />
            </Card>
        </Row>
    );
};
