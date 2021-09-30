import React from 'react';
import {Grid, Row, Card } from 'antd';

import LoginForm from '../../components/loginForm';

export const Login = () => {
  const onFinish = () => {
    console.log('Success:');
  };

  const onFinishFailed = () => {
    console.log('Failed:');
  };

  return (
    <Row>
      <Card title="Login">
        <LoginForm
          onFinishSuccessCallback={onFinish}
          onFinishFailedCallback={onFinishFailed}
        />
      </Card>
    </Row>
    
  )
    
};
