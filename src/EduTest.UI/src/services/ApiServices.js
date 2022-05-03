const baseUrl = process.env.VUE_APP_IIS_SERVER;

const authMethods = {
    login: `${baseUrl}/api/auth/login`,
    signin: `${baseUrl}/api/auth/signin`,
    logout: `${baseUrl}/api/auth/logout`
}

const studentMethods = {
    get: `${baseUrl}/api/student/get/`,
    getAll: `${baseUrl}/api/student/getall`,
    add: `${baseUrl}/api/student/add`,
    update: `${baseUrl}/api/student/update/`,
    delete: `${baseUrl}/api/student/remove/`,
}

export default {
    authMethods,
    studentMethods
}