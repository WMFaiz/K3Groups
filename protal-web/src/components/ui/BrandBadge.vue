<template>
  <div class="brand-badge" :title="brand">
    <span class="brand-dot" />
    <span class="brand-name">{{ brand }}</span>
  </div>
</template>
<script setup lang="ts">
const props = defineProps<{ brand: string }>()
</script>