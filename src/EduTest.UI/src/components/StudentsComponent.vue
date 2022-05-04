<template>
    <div class="container my-5">
        <div class="row my-3">
            <div class="col pt-1">
                <input type="text" placeholder="Buscar estudiante" class="form-control" required>
            </div>
            <div class="col">
                <button class="btn btn-primary">Filtrar</button>
            </div>
        </div>
        <table class="table table-hover">
            <thead class="thead-dark">
                <tr>
                    <th scope="col">ID</th>
                    <th scope="col">Nombre</th>
                    <th scope="col">Apellidos</th>
                    <th scope="col">Nacimiento</th>
                    <th scope="col">Correo</th>
                    <th scope="col">Curso (ID)</th>
                    <th scope="col">Materia (ID)</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="student in studentList" :key="student.id" @click="editMethod(student.id)" class="table_row">
                    <td scope="row">{{ student.id }}</td>
                    <td>{{ student.firstName }}</td>
                    <td>{{ student.lastName }}</td>
                    <td>{{ changeFormat(new Date(student.dateOfBirth)) }}</td>
                    <td>{{ student.email }}</td>
                    <td>{{ student.courseId !== undefined ? student.courseId : "Ninguno" }}</td>
                    <td>{{ student.matterId !== undefined ? student.matterId : "Ninguno" }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    import axios from "axios"
    import routes from '@/services/ApiServices.js'
    import moment from 'moment'
    export default {
        name: "StudentsComponent",
        data: function(){
            return {
                studentList:null,
                course:""
            }
        },
        mounted: function(){
            axios.get(routes.studentMethods.getAll, { withCredentials: true })
            .then((response) => {
                if (response.status === 200) {
                    this.studentList = response.data.content;
                }else{
                    console.log(response);
                }
            }).catch((error) => {
                console.log(error);
            });
        },
        methods:{
            editMethod(id){
                this.$router.push(`/editstudent/${id}`);
            },
            changeFormat(date){
                return moment(date).format('DD-MM-YYYY');
            }
        }
    }
</script>

<style scoped>
    .table_row{
        cursor: pointer;
    }
</style>