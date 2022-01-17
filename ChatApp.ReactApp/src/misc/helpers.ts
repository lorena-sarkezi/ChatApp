import axios from "../axios"
import { AxiosRequestConfig } from "axios";

// eslint-disable-next-line @typescript-eslint/no-unused-vars
const checkIfAuthenticated = async () => {
    const token = window.localStorage.getItem("bearer");
    if(token === null){
        return null;
    }

    const config: AxiosRequestConfig = {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    } 

    let authStatus = false;

    try{
        await axios.get<undefined, string>('/api/auth/validate', config);
        authStatus = true;
    }
    catch(e){
        authStatus = false;
    }

    return Promise.resolve(authStatus);
}

const AuthHelpers = {
    checkIfAuthenticated: checkIfAuthenticated
}

export default AuthHelpers;