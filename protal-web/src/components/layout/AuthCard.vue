<template>
  <div class="container">
    <div class="card" role="region" aria-label="Authentication">
      <header style="display:flex; justify-content:space-between; align-items:center; margin-bottom: 18px;">
        <div style="display:flex; gap:12px; align-items:center;">
          <BrandBadge :brand="brand" />
        </div>
        <slot name="header-cta" />
      </header>
      <slot />
      <footer style="margin-top: 18px;">
        <slot name="footer" />
      </footer>
    </div>
    <p class="p-muted" style="text-align:center; margin-top: 14px;">© {{ new Date().getFullYear() }} K3 Client Portal
    </p>
  </div>
</template>
<script setup lang="ts">
import BrandBadge from '../ui/BrandBadge.vue'
const props = withDefaults(defineProps<{ brand?: string }>(), { brand: 'K3 Default' })
</script>