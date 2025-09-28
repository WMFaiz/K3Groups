<template>
  <AuthCard :brand="brand">
    <h1>Forgot password</h1>
    <p class="p-muted">We’ll email you a reset link.</p>
    <div class="row">
      <BaseInput id="email" label="Email" type="email" placeholder="you@company.com" v-model="email"
        :error="errors.email" />
      <BaseButton :disabled="loading" @click="onSubmit">{{ loading ? 'Sending…' : 'Send reset link' }}</BaseButton>
    </div>
    <template #footer>
      <RouterLink class="link" to="/login">Back to sign in</RouterLink>
    </template>
  </AuthCard>
</template>
<script setup lang="ts">
import { reactive, ref } from 'vue'
import AuthCard from '../../components/layout/AuthCard.vue'
import BaseInput from '../../components/ui/BaseInput.vue'
import BaseButton from '../../components/ui/BaseButton.vue'


const brand = 'K3 Default'
const email = ref('')
const loading = ref(false)
const errors = reactive<{ email?: string }>({})


function validate() {
  errors.email = !/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email.value) ? 'Enter a valid email' : ''
  return !errors.email
}


async function onSubmit() {
  if (!validate()) return
  loading.value = true
  try { await new Promise(r => setTimeout(r, 600)) } finally { loading.value = false }
}
</script>