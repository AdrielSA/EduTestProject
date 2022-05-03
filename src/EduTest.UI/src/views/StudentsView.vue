<template>
    <div>
        <HeaderComponentVue />
        <StudentsComponentVue />
        <FooterComponentVue />
    </div>
</template>

<script>
import HeaderComponentVue from "@/components/HeaderComponent.vue"
import FooterComponentVue from "@/components/FooterComponent.vue"
import StudentsComponentVue from '@/components/StudentsComponent.vue'
export default {
    name: "StudentsView",
    components: {
        HeaderComponentVue,
        FooterComponentVue,
        StudentsComponentVue
    },
    data: function(){
        return {

        }
    },
    methods:{

    }
}
</script>