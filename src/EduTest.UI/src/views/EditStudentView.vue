<template>
    <div v-if="student">
        <HeaderComponentVue />
        <div class="mt-5 text-center">
            <h3>ID del Estudiante: {{student.id}}</h3>
        </div>
        <div class="w-75 mx-auto m-5 border border-1 p-5">
            <form @submit.prevent="updateMethod">
                <div class="row mb-4">
                    <div class="col">
                        <div class="form-outline">
                            <label class="form-label" for="firstname">Nombre</label>
                            <input type="text" id="firstname" class="form-control" v-model="student.firstName" required />
                        </div>
                    </div>
                    <div class="col">
                        <div class="form-outline">
                            <label class="form-label" for="lastname">Apellidos</label>
                            <input type="text" id="lastname" class="form-control" v-model="student.lastName" required />
                        </div>
                    </div>
                </div>
                <div class="row mb-4">
                    <div class="col">
                        <div class="form-outline">
                            <label class="form-label" for="course">Curso</label>
                            <select name="courses" id="course" class="custom-select" v-model="student.courseId">
                                <option v-for="course in courses" :key="course.id" v-bind:value="course.id">{{ course.name }}</option>
                            </select>
                        </div>
                    </div>
                    <div class="col">
                        <div class="form-outline">
                            <label class="form-label" for="matter">Materia</label>
                            <select name="matters" id="matter" class="custom-select" v-model="student.matterId">
                                <option v-for="matter in matters" :key="matter.id" v-bind:value="matter.id">{{ matter.name }}</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class="form-outline mb-4">
                    <label class="form-label" for="email">Correo</label>
                    <input type="email" id="email" class="form-control" v-model="student.email" required />
                </div>
                <div class="form-outline mb-4">
                    <label class="form-label" for="dateOfBirth">Nacimiento</label>
                    <input type="date" id="dateOfBirth" class="form-control" v-model="student.dateOfBirth" required />
                </div>
                <div class="row mt-5 text-center">
                    <div class="col">
                        <button type="submit" class="btn btn-primary">Actualizar</button>
                        <button type="button" @click="deleteMethod" class="btn btn-danger">Eliminar</button>
                    </div>
                    <div class="col">
                        <button type="button" @click="backMethod" class="btn btn-secondary">Cancelar</button>
                    </div>
                </div>
            </form>
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
            student:null,
            courses:null,
            matters:null
        }
    },
    mounted:function(){
        this.getStudent();
        this.getCourses();
        this.getMatters();
    },
    methods: {
        getStudent(){
            axios.get(`${routes.studentMethods.get}${this.$route.params.id}`, { withCredentials: true })
            .then((response) => {
                this.student = response.data.content;
            }).catch((error) => {
                console.log(error);
            });
        },
        getCourses(){
            axios.get(routes.courseMethods.getAll, { withCredentials: true })
            .then((response) => {
                this.courses = response.data.content;
            }).catch((error) => {
                console.log(error);
            });
        },
        getMatters(){
            axios.get(routes.matterMethods.getAll, { withCredentials: true })
            .then((response) => {
                this.matters = response.data.content;
            }).catch((error) => {
                console.log(error);
            });
        },
        deleteMethod(){
            axios.delete(`${routes.studentMethods.delete}${this.student.id}`, { withCredentials:true })
            .then(() => {
                this.backMethod();
            }).catch((error) => {
                console.log(error)
            });
        },
        updateMethod(){
            axios.put(`${routes.studentMethods.update}${this.student.id}`, this.student, { withCredentials:true })
            .then(() => {
                this.backMethod();
            }).catch((error) => {
                console.log(error);
            })
        },
        backMethod(){
            this.$router.push('/students');
        }
    }
}
</script>

<style scoped>

</style>