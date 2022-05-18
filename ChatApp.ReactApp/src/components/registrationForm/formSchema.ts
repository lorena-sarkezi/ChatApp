import * as yup from "yup";

export interface IRegistrationFormInputs {
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    confirmPassword: string;
}

export const registrationFormSchema = yup.object({
    firstName: yup.string().required("First name is required"),
    lastName: yup.string().required("Last name is required"),
    email: yup.string().required("E-mail is required").email("Invalid E-Mail"),
    password: yup.string().required("Password is required").min(8, "Password must be atleast 8 characters"),
    confirmPassword: yup.string().required("Password confirmation is required").oneOf([yup.ref("password"), null], "Passwords do not match")
});
