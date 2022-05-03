<template>
    <div>
        <HeaderComponentVue />
        <div class="container">
            <div class="form-group">

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