<template>
  <div class="home text-center">
    <HeaderComponent />
    <h1>Inicio</h1>
  </div>
</template>

<script>
import HeaderComponent from '@/components/HeaderComponent.vue'
export default {
  name: 'HomeView',
  components: {
    HeaderComponent
  }
}
</script>
