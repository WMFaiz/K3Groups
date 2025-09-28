<template>
  <AuthCard :brand="brand">
    <h1>Reset password</h1>
    <p class="p-muted">Enter your new password.</p>
    <div class="row">
      <BaseInput id="password" label="New password" type="password" v-model="password" :error="errors.password" />
      <BaseInput id="confirm" label="Confirm password" type="password" v-model="confirm" :error="errors.confirm" />
      <BaseButton :disabled="loading" @click="onSubmit">{{ loading ? 'Updating…' : 'Update password' }}</BaseButton>
    </div>
  </AuthCard>
</template>
<script setup lang="ts">
import { reactive, ref } from 'vue'
import AuthCard from '../../components/layout/AuthCard.vue'
import BaseInput from '../../components/ui/BaseInput.vue'
import BaseButton from '../../components/ui/BaseButton.vue'


const brand = 'K3 Default'
const password = ref('')
const confirm = ref('')
const loading = ref(false)
const errors = reactive<{ password?: string; confirm?: string }>({})


function validate() {
  errors.password = password.value.length < 8 ? 'At least 8 characters' : ''
  errors.confirm = confirm.value !== password.value ? 'Passwords do not match' : ''
  return !errors.password && !errors.confirm
}
async function onSubmit() { if (validate()) { loading.value = true; try { await new Promise(r => setTimeout(r, 600)); location.assign('/login') } finally { loading.value = false } } }
</script>