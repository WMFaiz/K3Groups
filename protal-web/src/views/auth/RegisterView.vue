<template>
  <AuthCard :brand="brand">
    <h1>Create account</h1>
    <p class="p-muted">Start your journey with K3.</p>


    <div class="row">
      <BaseInput id="name" label="Full name" placeholder="Jane Doe" v-model="name" :error="errors.name" />
      <BaseInput id="email" label="Email" type="email" autocomplete="email" placeholder="you@company.com"
        v-model="email" :error="errors.email" />
      <BaseInput id="password" label="Password" type="password" autocomplete="new-password"
        placeholder="At least 8 characters" v-model="password" :error="errors.password" />
      <BaseButton :disabled="loading" @click="onSubmit">{{ loading ? 'Creating…' : 'Create account' }}</BaseButton>
    </div>


    <template #footer>
      <p class="p-muted" style="text-align:center">Already have an account? <RouterLink class="link" to="/login">Sign in
        </RouterLink>
      </p>
    </template>
  </AuthCard>
</template>
<script setup lang="ts">
import { reactive, ref } from 'vue'
import AuthCard from '../../components/layout/AuthCard.vue'
import BaseInput from '../../components/ui/BaseInput.vue'
import BaseButton from '../../components/ui/BaseButton.vue'


const brand = 'K3 Default'
const name = ref('')
const email = ref('')
const password = ref('')
const loading = ref(false)
const errors = reactive<{ name?: string; email?: string; password?: string }>({})


function validate() {
  errors.name = name.value.trim().length < 2 ? 'Please enter your name' : ''
  errors.email = !/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email.value) ? 'Enter a valid email' : ''
  errors.password = password.value.length < 8 ? 'At least 8 characters' : ''
  return !errors.name && !errors.email && !errors.password
}


async function onSubmit() {
  if (!validate()) return
  loading.value = true
  try {
    await new Promise(r => setTimeout(r, 600))
    window.location.assign('/login')
  } finally { loading.value = false }
}
</script>