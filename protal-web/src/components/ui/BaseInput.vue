<template>
  <div class="row">
    <label v-if="label" :for="id" class="label">{{ label }}</label>
    <input :id="id" class="input" :type="type" :inputmode="inputmode" :autocomplete="autocomplete"
      :placeholder="placeholder" v-model="model" :aria-invalid="error ? 'true' : 'false'"
      :aria-describedby="error ? `${id}-err` : undefined" @keyup.enter="$emit('enter')" />
    <p v-if="error" :id="`${id}-err`" class="err">{{ error }}</p>
  </div>
</template>


<script setup lang="ts">
import { computed } from 'vue'
import type { InputHTMLAttributes } from 'vue'


// Use the DOM-accurate unions from Vue's types
// This matches runtime-dom.d.ts and fixes the inputmode/type error
export type InputMode = InputHTMLAttributes['inputmode']
export type InputType = InputHTMLAttributes['type']


const props = withDefaults(defineProps<{
  id: string
  label?: string
  type?: InputType
  inputmode?: InputMode
  autocomplete?: string
  placeholder?: string
  modelValue?: string
  error?: string
}>(), {
  type: 'text'
})


const emit = defineEmits<{
  (e: 'update:modelValue', v: string): void
  (e: 'enter'): void
}>()


const model = computed({
  get: () => props.modelValue ?? '',
  set: (v: string) => emit('update:modelValue', v)
})
</script>