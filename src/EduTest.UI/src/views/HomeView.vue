<template>
  <div class="home text-center">
    <HeaderComponentVue />
    <!-- <h1>Inicio</h1> -->
    <FooterComponentVue />
  </div>
</template>

<script>
import HeaderComponentVue from '@/components/HeaderComponent.vue'
import FooterComponentVue from '@/components/FooterComponent.vue'
export default {
  name: 'HomeView',
  components: {
    HeaderComponentVue,
    FooterComponentVue
  }
}
</script>
