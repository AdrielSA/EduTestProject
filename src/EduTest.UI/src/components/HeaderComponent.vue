<template>
    <header>
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <a class="navbar-brand" href="/home">Sistema de estudiantes</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                <div class="navbar-nav">
                    <a class="nav-item nav-link" href="/home">Inicio</a>
                    <a class="nav-item nav-link" href="/students">Estudiantes</a>
                    <a class="nav-item nav-link" href="#">Materias</a>
                    <a class="nav-item nav-link" href="#">Cursos</a>
                </div>
                <div class="auth_controls">
                    <button class="btn_logout" @click="logoutMethod">Cerrar sesión</button>
                </div>
            </div>
        </nav>
    </header>
</template>

<script>
import axios from "axios"
import routes from '@/services/ApiServices.js'
export default {
    name:'HeaderComponent',
    data: function () {
        return{
            
        }
    },
    methods:{
        logoutMethod(){
            axios.post(routes.authMethods.logout, { withCredentials: true })
            .then(() => {
                localStorage.removeItem('isLogged');
                this.$router.push('/');
            }).catch((error) => {
                console.log(error)
            });
        }
    }
}
</script>

<style scoped>
    .auth_controls {
        margin-left: 60%;
    }
    .btn_logout {
        background: none;
        color: inherit;
        border: none;
        padding: 0;
        font: inherit;
        cursor: pointer;
        outline: inherit;
    }
</style>