<template>
    <div class="container my-5">
        <table class="table table-hover">
            <thead class="thead-dark">
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">First</th>
                    <th scope="col">Last</th>
                    <th scope="col">Handle</th>
                    <th scope="col">Acciones</th>
                </tr>
            </thead>
            <tbody>
                
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

            }
        },
        mounted: function(){
            axios.get(routes.studentMethods.getAll, { withCredentials: true })
            .then((response) => {
                console.log(response);
            }).catch((error) => {
                console.log(error);
            });
        }
    }
</script>

<style scoped>

</style>