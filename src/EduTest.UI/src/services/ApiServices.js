const baseUrl = process.env.VUE_APP_IIS_SERVER;

const authMethods = {
    login: `${baseUrl}/api/auth/login`,
    signin: `${baseUrl}/api/auth/signin`,
    logout: `${baseUrl}/api/auth/logout`
}

const studentMethods = {
    get: ``,
    getAll: `${baseUrl}/api/student/getall`,
    add: ``,
    update: ``,
    delete: ``,
}

export default {
    authMethods,
    studentMethods
}