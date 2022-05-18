import { Card, Row } from "antd";
import React from "react";
import RegistrationForm from "../../components/registrationForm";

export const Register = () => {
    return(
        <Row className="container-centered">
            <Card title="Register an account" style={{width:"350px"}}>
                <RegistrationForm />
            </Card>
        </Row>
    )
}