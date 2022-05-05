<template>
    <div class="container my-5">
        <div class="row my-3">
            <div class="col pt-1">
                <input type="text" placeholder="Filtrar por curso" class="form-control" v-model="filter">
            </div>
            <div class="col">
                <button @click="searchMethod" class="btn btn-primary">Filtrar</button>
            </div>
            <div class="col r-button">
                <button @click="addMethod" class="btn btn-primary">Agregar</button>
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
                    <th scope="col">Fecha Entrada</th>
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
                    <td>{{ changeFormat(new Date(student.entryDate)) }}</td>
                </tr>
            </tbody>
        </table>
        <div class="text-center mt-5">
            <a class="px-3" @click="pagination(metaData.previousPageUrl)" href="#">atrás</a>
            <span v-if="metaData">
                <a class="px-1" v-for="(e, i) in metaData.totalPage" :key="i" href="#">{{ i+1 }}</a>
            </span>
            <a class="px-3" @click="pagination(metaData.nextPageUrl)" href="#">siguiente</a>
        </div>
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
                metaData:null,
                filter:null
            }
        },
        mounted: function(){
            axios.get(routes.studentMethods.getAll, { withCredentials: true })
            .then((response) => {
                if (response.status === 200) {
                    this.studentList = response.data.content;
                    this.metaData = response.data.metaData;
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
            addMethod(){
                this.$router.push(`/addstudent`);
            },
            changeFormat(date){
                return moment(date).format('DD-MM-YYYY');
            },
            pagination(url){
                axios.get(url, { withCredentials: true })
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
            searchMethod(){

            }
        }
    }
</script>

<style scoped>
    .table_row{
        cursor: pointer;
    }

    .r-button {
        position: absolute;
        right: -85%;
    }
</style>