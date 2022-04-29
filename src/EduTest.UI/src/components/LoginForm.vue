<template>
    <div class="container border border-1 p-5">
        <form @submit.prevent="loginMethod">
            <div class="text-secondary mb-4">
                <h3>Inicio de Sesión</h3>
            </div>
            <div class="form-outline mb-4">
                <label class="form-label" for="loginUser">Usuario</label>
                <input type="text" id="loginUser" class="form-control" v-model="userName" required />
            </div>
            <div class="form-outline mb-5">
                <label class="form-label" for="loginPassword">Contraseña</label>
                <input type="password" id="loginPassword" class="form-control" v-model="password" required />
            </div>
            <button type="submit" class="btn btn-primary btn-block mb-4">Iniciar Sesión</button>
        </form>
    </div>
</template>

<script>
    import axios from "axios"
    import routes from '@/services/ApiServices.js'

    export default {
        name: "LoginForm",
        data: function(){
            return{
                userName:"",
                password:"",
                error:false,
                errorMsg:""
            }
        },
        methods:{
            loginMethod(){
                let json = {
                    "userName": this.userName,
                    "password": this.password
                }
                axios.post(routes.authMethods.login, json, { withCredentials: true })
                .then((reponse) => {
                    console.log(reponse);
                }).catch((error) => {
                    console.log(error);
                });
            }
        }
    }
</script>