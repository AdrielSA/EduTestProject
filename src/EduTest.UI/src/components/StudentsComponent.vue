<template>
    <div class="container my-5">
        <table class="table table-hover">
            <thead class="thead-dark">
                <tr>
                    <th scope="col">ID</th>
                    <th scope="col">Nombre</th>
                    <th scope="col">Apellidos</th>
                    <th scope="col">Nacimiento</th>
                    <th scope="col">Correo</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="student in studentList" :key="student.id" @click="editMethod(student.id)" class="table_row">
                    <td scope="row">{{ student.id }}</td>
                    <td>{{ student.firstName }}</td>
                    <td>{{ student.lastName }}</td>
                    <td>{{ student.dateOfBirth }}</td>
                    <td>{{ student.email }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    import axios from "axios"
    import routes from '@/services/ApiServices.js'
    export default {
        name: "StudentsComponent",
        data: function(){
            return {
                studentList:null
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
            }
        }
    }
</script>

<style scoped>
    .table_row{
        cursor: pointer;
    }
</style>