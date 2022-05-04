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

const courseMethods = {
    get: `${baseUrl}/api/course/get/`,
    getAll: `${baseUrl}/api/course/getall`,
    add: `${baseUrl}/api/course/add`,
    update: `${baseUrl}/api/course/update/`,
    delete: `${baseUrl}/api/course/remove/`,
}

const matterMethods = {
    get: `${baseUrl}/api/matter/get/`,
    getAll: `${baseUrl}/api/matter/getall`,
    add: `${baseUrl}/api/matter/add`,
    update: `${baseUrl}/api/matter/update/`,
    delete: `${baseUrl}/api/matter/remove/`,
}

export default {
    authMethods,
    studentMethods,
    courseMethods,
    matterMethods
}