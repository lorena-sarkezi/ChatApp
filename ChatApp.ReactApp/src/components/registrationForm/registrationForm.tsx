import React from "react"
import { useForm, Controller, SubmitHandler } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import { IRegistrationFormInputs, registrationFormSchema } from "./formSchema";

import { Input, Button } from "antd";

import '../../index.css';

export const RegistrationForm: React.FC = () => {
    const { register, handleSubmit, reset, formState: {errors} } = useForm<IRegistrationFormInputs>({
        resolver: yupResolver(registrationFormSchema)
    });

    const onFormSubmit: SubmitHandler<IRegistrationFormInputs> = data => {
        console.log(data);
    }

    return(
        <form onSubmit={handleSubmit(onFormSubmit)}>
            <label>First name:</label>
            <Input {...register("firstName")} />
            <p className="form-error">{errors.firstName?.message}</p>

            <label>Last name:</label>
            <Input {...register("lastName")} />
            <p className="form-error">{errors.lastName?.message}</p>
                
            <label>E-Mail</label>
            <Input {...register("email")} />
            <p className="form-error">{errors.email?.message}</p>

            <label>Password:</label>
            <Input {...register("password")} />
            <p className="form-error">{errors.password?.message}</p>

            <label>Confirm password:</label>
            <Input {...register("confirmPassword")} />
            <p className="form-error">{errors.confirmPassword?.message}</p>

            <Button type="primary" htmlType="submit" className="submit-btn button-separation">Submit</Button>
        </form>
    )
}