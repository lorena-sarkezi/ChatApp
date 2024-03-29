import axios from 'axios';

const axiosClient = () => {
    const defaultOptions = {
      baseURL: 'https://localhost:44395/',
      headers: {
        'Content-Type': 'application/json',
      },
    };

    const instance = axios.create(defaultOptions);

    return instance;
}

export default axiosClient();