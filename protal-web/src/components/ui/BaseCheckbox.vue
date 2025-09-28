<template>
  <label class="label" style="display:flex; align-items:center; gap:10px; cursor:pointer">
    <input type="checkbox" :checked="model"
      @change="emit('update:modelValue', ($event.target as HTMLInputElement).checked)" />
    <span>
      <slot />
    </span>
  </label>
</template>
<script setup lang="ts">
const props = defineProps<{ modelValue?: boolean }>()
const emit = defineEmits(['update:modelValue'])
const model = props.modelValue ?? false
</script>