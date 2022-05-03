<template>
    <div class="container-lg my-5">
        <LoginForm />
    </div>
</template>

<script>
    import LoginForm from '@/components/LoginForm.vue'
    export default {
        name: 'LoginView',
        components: {
            LoginForm
        }
    }
</script>

<style scoped>
    .container {
        width: 40rem;
        height: 30rem;
    }
</style>