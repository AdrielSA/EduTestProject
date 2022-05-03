const baseUrl = process.env.VUE_APP_IIS_SERVER;

const authMethods = {
    login: `${baseUrl}/api/auth/login`,
    signin: `${baseUrl}/api/auht/signin`,
    logout: `${baseUrl}/api/auht/logout`
}

export default {
    authMethods
}