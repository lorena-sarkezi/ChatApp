import React from "react"
import { useForm, Controller, SubmitHandler } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import { Input, Button } from "antd";

import { IRegistrationFormInputs, registrationFormSchema } from "./formSchema";
import axios from '../../axios';

import '../../index.css';
import { IRegister } from "../../models/IRegister";
import backendRoutes from "../../misc/backendRoutes";

export const RegistrationForm: React.FC = () => {

    

    const {control, handleSubmit, formState: {errors} } = useForm<IRegistrationFormInputs>({
        resolver: yupResolver(registrationFormSchema)
    });

    const onFormSubmit: SubmitHandler<IRegistrationFormInputs> = async data => {
        console.log(data);

        const registrationRequest: IRegister = {
            firstName: data.firstName,
            lastName: data.lastName,
            email: data.email,
            password: btoa(data.password), // Base64,
            passwordConfirm: btoa(data.confirmPassword)
        };

        await axios.post(backendRoutes.auth.register, registrationRequest);
    }

    return(
        <form onSubmit={handleSubmit(onFormSubmit)}>
            <label>First name:</label>
            <Controller
                name="firstName"
                control={control}
                render={({ field }) => <Input {...field} />}
            />
            <p className="form-error">{errors.firstName?.message}</p>

            <label>Last name:</label>
            <Controller
                name="lastName"
                control={control}
                render={({ field }) => <Input {...field} />}
            />
            <p className="form-error">{errors.lastName?.message}</p>
                
            <label>E-Mail</label>
            <Controller
                name="email"
                control={control}
                render={({ field }) => <Input {...field} />}
            />
            <p className="form-error">{errors.email?.message}</p>

            <label>Password:</label>
            <Controller
                name="password"
                control={control}
                render={({ field }) => <Input type="password" {...field} />}
            />
            <p className="form-error">{errors.password?.message}</p>

            <label>Confirm password:</label>
            <Controller
                name="confirmPassword"
                control={control}
                render={({ field }) => <Input type="password" {...field} />}
            />
            <p className="form-error">{errors.confirmPassword?.message}</p>

            <Button type="primary" htmlType="submit" className="submit-btn button-separation">Submit</Button>
        </form>
    )
}