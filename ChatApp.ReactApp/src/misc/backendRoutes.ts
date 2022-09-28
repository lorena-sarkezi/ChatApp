const backendroutes = () => {
    const routes = {
        auth: {
            login: "/api/auth/authenticate",
            register: '/api/auth/register'
        }
    }

    return routes;
}

export default backendroutes();