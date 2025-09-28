<template>
  <div :data-brand="brand" id="app">
    <RouterView />
  </div>
</template>
<script setup lang="ts">
const brand = 'aurora'
</script>
<style>
@import url('./assets/theme.css');
</style>