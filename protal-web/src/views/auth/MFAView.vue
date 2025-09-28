<template>
  <AuthCard :brand="brand">
    <h1>Two‑factor verification</h1>
    <p class="p-muted">Enter the 6‑digit code from your authenticator app.</p>
    <div class="otp">
      <input v-for="i in 6" :key="i" maxlength="1" class="input" inputmode="numeric" pattern="[0-9]*"
        @input="onInput($event, i)" ref="setRef" />
    </div>
    <div class="helper" style="margin-top:12px;">
      <RouterLink class="link" to="/login">Use a different method</RouterLink>
      <button class="btn-ghost" @click="resend" :disabled="cooldown > 0">Resend {{ cooldown > 0 ? `(${cooldown}s)` : ''
        }}</button>
    </div>
  </AuthCard>
</template>
<script setup lang="ts">
import { onMounted, ref } from 'vue'
import AuthCard from '../../components/layout/AuthCard.vue'


const brand = 'K3 Default'
const inputs = ref<HTMLInputElement[]>([])
const setRef = (el: HTMLInputElement) => { if (el) inputs.value.push(el) }
const cooldown = ref(0)


function onInput(e: Event, i: number) {
  const t = e.target as HTMLInputElement
  if (!/^[0-9]$/.test(t.value)) { t.value = ''; return }
  if (i < 6) inputs.value[i]?.focus()
  if (inputs.value.every(x => x.value)) submit()
}


function submit() {
  const code = inputs.value.map(x => x.value).join('')
  localStorage.setItem('mfa', code)
  location.assign('/')
}


function resend() { cooldown.value = 30; const iv = setInterval(() => { cooldown.value--; if (cooldown.value <= 0) clearInterval(iv) }, 1000) }


onMounted(() => inputs.value[0]?.focus())
</script>