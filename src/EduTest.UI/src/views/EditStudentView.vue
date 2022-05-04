<template>
    <div>
        <HeaderComponentVue />
        <div class="w-50 mx-auto m-5 border border-1 p-5">
            <div class="row mb-4">
                <div class="col">
                    <div class="form-outline">
                        <label class="form-label" for="firstname">Nombre</label>
                        <input type="text" id="firstname" class="form-control" />
                    </div>
                </div>
                <div class="col">
                    <div class="form-outline">
                        <label class="form-label" for="lastname">Apellidos</label>
                        <input type="text" id="lastname" class="form-control" />
                    </div>
                </div>
            </div>
            <div class="form-outline mb-4">
                <label class="form-label" for="dateOfBirth">Nacimiento</label>
                <input type="date" id="dateOfBirth" class="form-control" />
            </div>
            <div class="form-outline mb-4">
                <label class="form-label" for="email">Correo</label>
                <input type="email" id="email" class="form-control" />
            </div>
            <div class="row mb-4">
                <div class="col">
                    <div class="form-outline">
                        <label class="form-label" for="firstname">Curso</label>
                        <select name="courses" id="" class="custom-select"></select>
                    </div>
                </div>
                <div class="col">
                    <div class="form-outline">
                        <label class="form-label" for="lastname">Materia</label>
                        <select name="matters" id="" class="custom-select"></select>
                    </div>
                </div>
            </div>
        </div>
        <FooterComponentVue />
    </div>
</template>

<script>
import HeaderComponentVue from "@/components/HeaderComponent.vue"
import FooterComponentVue from "@/components/FooterComponent.vue"
import axios from "axios"
import routes from '@/services/ApiServices.js'
export default {
    name: 'SeeStudentView',
    components: {
        HeaderComponentVue,
        FooterComponentVue
    },
    data:function(){
        return{
            student:null
        }
    },
    mounted:function(){
        axios.get(`${routes.studentMethods.get}${this.$route.params.id}`, { withCredentials: true })
        .then((reponse) => {
            this.student = reponse.data.content;
        }).catch((error) => {
            console.log(error);
        });
    }
}
</script>

<style scoped>

</style>