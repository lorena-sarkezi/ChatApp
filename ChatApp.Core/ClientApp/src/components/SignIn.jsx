import React, {useState, useEffect} from 'react';

import axios from 'axios';
import { useForm } from 'react-hook-form';

import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import Link from '@material-ui/core/Link';
import Grid from '@material-ui/core/Grid';
import Box from '@material-ui/core/Box';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';

function Copyright() {
  return (
    <Typography variant="body2" color="textSecondary" align="center">
      {'Copyright © '}
      <Link color="inherit" href="https://material-ui.com/">
        Your Website
      </Link>{' '}
      {new Date().getFullYear()}
      {'.'}
    </Typography>
  );
}

const useStyles = makeStyles((theme) => ({
  paper: {
    marginTop: theme.spacing(8),
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
  },
  avatar: {
    margin: theme.spacing(1),
    backgroundColor: theme.palette.secondary.main,
  },
  form: {
    width: '100%', // Fix IE 11 issue.
    marginTop: theme.spacing(1),
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
  },
}));

const formError = {
  isUsernameEmpty: false,
  isPasswordEmpty: false
};

const formEmpty ={
  username:"",
  password:"",
  remember:false
}

export default function SignIn(props) {
  const classes = useStyles();

  const [credentialsInvalid, setCredentialsInvalid] = useState(false);
  const [formData, setFormData] = useState(formEmpty);
  const [formErrorStatus, setFormErrorStatus] = useState(formError);

  const handleFormChange = (value, prop) => {
    var data = {...formData};
    data[prop] = value;
    setFormData(data);
  }

  const validateForm = () => {
    let isValid = true;

    let formErrorTemp = {...formErrorStatus};
    formErrorTemp.isUsernameEmpty = false;
    formErrorTemp.isPasswordEmpty = false;

    if(formData.username === ""){
      formErrorTemp.isUsernameEmpty = true;
      isValid = false
    }

    if(formData.password === ""){
      formErrorTemp.isPasswordEmpty = true;
      isValid = false;
    }

    setFormErrorStatus(formErrorTemp);
    //setFormErrorStatus(isValid);
    console.log(isValid);
    console.log(formData);
    return isValid;
  }

  const handleFormSubmit = () =>{
    if(validateForm()){
      let formattedData = {...formData};
      formattedData.password = btoa(formattedData.password); //Base64 encode

      let axiosOptions = {
        method:'POST',
        url:'/api/auth/authenticate',
        data: formattedData
      };

      axios(axiosOptions)
      .then((response) =>{
        if(response.status === 200){
          Window.localStorage.setItem("token", response.content);
          this.props.history.push('/');
        }
      })
      .catch(error =>{
        console.log(error.response.status);
      });
    }
  }

  useEffect(()=>{
    console.log(formData);
    console.log(formErrorStatus);
  },[formData, formErrorStatus, credentialsInvalid]);
  

  return (
    <Container component="main" maxWidth="xs">
      <CssBaseline />
      <div className={classes.paper}>
        <Avatar className={classes.avatar}>
          <LockOutlinedIcon />
        </Avatar>
        <Typography component="h1" variant="h5">
          Sign in
        </Typography>
        <form className={classes.form}>
          <TextField
            variant="outlined"
            margin="normal"
            required
            fullWidth
            id="email"
            label="E-Mail or Username"
            name="email"
            autoComplete="email"
            autoFocus
            onChange ={(event) => handleFormChange(event.target.value,"username")}
            error={formErrorStatus.isUsernameEmpty}
          />
          <TextField
            variant="outlined"
            margin="normal"
            required
            fullWidth
            name="password"
            label="Password"
            type="password"
            id="password"
            onChange ={(event) => handleFormChange(event.target.value, "password")}
            autoComplete="current-password"
            error={formErrorStatus.isPasswordEmpty}
          />
          <FormControlLabel
            control={<Checkbox value="remember" color="primary" onChange={(event) => handleFormChange(event.target.checked, "remember")}/>}
            label="Remember me"
          />
          <Button
            type="button"
            fullWidth
            variant="contained"
            color="primary"
            className={classes.submit}
            onClick={handleFormSubmit}
          >
            Sign In
          </Button >
          <Grid container>
            <Grid item xs>
              <Link href="#" variant="body2">
                Forgot password?
              </Link>
            </Grid>
            <Grid item>
              <Link href="/register" variant="body2">
                {"Don't have an account? Sign Up"}
              </Link>
            </Grid>
          </Grid>
        </form>
      </div>
      <Box mt={8}>
        <Copyright />
      </Box>
    </Container>
  );
}