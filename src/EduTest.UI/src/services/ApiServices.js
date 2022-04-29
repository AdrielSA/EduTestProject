// const baseUrl = process.env.VUE_APP_URL;

const baseUrl = "https://localhost:5001";

const authMethods = {
    login: `${baseUrl}/api/auth/login`,
    signin: `${baseUrl}/api/auht/signin`,
    logout: `${baseUrl}/api/auht/logout`
}

export default {
    authMethods
}