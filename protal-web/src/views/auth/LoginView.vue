<template>
  <AuthCard :brand="brand">
    <h1>Welcome back</h1>
    <p class="p-muted">Sign in to your account to continue.</p>


    <div class="row" style="margin-top: 10px;">
      <BaseInput id="email" label="Email" type="email" autocomplete="email" placeholder="you@company.com"
        v-model="email" :error="errors.email" @enter="onSubmit" />
      <BaseInput id="password" label="Password" type="password" autocomplete="current-password" placeholder="••••••••"
        v-model="password" :error="errors.password" @enter="onSubmit" />
      <div class="helper">
        <BaseCheckbox v-model="remember">Remember me</BaseCheckbox>
        <RouterLink class="link" to="/forgot">Forgot password?</RouterLink>
      </div>
      <BaseButton :disabled="loading" @click="onSubmit">{{ loading ? 'Signing in…' : 'Sign in' }}</BaseButton>
    </div>


    <template #footer>
      <p class="p-muted" style="text-align:center">New to K3? <RouterLink class="link" to="/register">Create an account
        </RouterLink>
      </p>
    </template>
  </AuthCard>
</template>


<script setup lang="ts">
import { reactive, ref } from 'vue'
import { useRouter } from 'vue-router'
import AuthCard from '../../components/layout/AuthCard.vue'
import BaseInput from '../../components/ui/BaseInput.vue'
import BaseCheckbox from '../../components/ui/BaseCheckbox.vue'
import BaseButton from '../../components/ui/BaseButton.vue'


const router = useRouter()
const email = ref('')
const password = ref('')
const remember = ref(true)
const loading = ref(false)
const brand = 'K3 Default'


const errors = reactive<{ email?: string; password?: string }>({})


function validate() {
  errors.email = !/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email.value) ? 'Please enter a valid email' : ''
  errors.password = password.value.length < 6 ? 'Password must be at least 6 characters' : ''
  return !errors.email && !errors.password
}


async function onSubmit() {
  if (!validate()) return
  loading.value = true
  try {
    const res = await fetch('/auth/login', { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify({ email: email.value, password: password.value }) })
    if (!res.ok) { throw new Error(await res.text()) }
    const data = await res.json()
    localStorage.setItem('token', data.accessToken)
    router.push('/')
  } catch (e: any) {
    errors.password = e?.message || 'Sign-in failed'
  } finally { loading.value = false }
}
</script>