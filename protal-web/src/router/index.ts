import { createRouter, createWebHistory } from 'vue-router'
import LoginView from '../views/auth/LoginView.vue'
import RegisterView from '../views/auth/RegisterView.vue'
import ForgotPasswordView from '../views/auth/ForgotPasswordView.vue'
import ResetPasswordView from '../views/auth/ResetPasswordView.vue'
import MFAView from '../views/auth/MFAView.vue'


const routes = [
  { path: '/', redirect: '/login' },
  { path: '/login', component: LoginView },
  { path: '/register', component: RegisterView },
  { path: '/forgot', component: ForgotPasswordView },
  { path: '/reset', component: ResetPasswordView },
  { path: '/mfa', component: MFAView },
]


export const router = createRouter({ history: createWebHistory(), routes })