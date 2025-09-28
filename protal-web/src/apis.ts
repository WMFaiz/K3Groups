import axios from 'axios';
export const api = axios.create({ baseURL: import.meta.env.VITE_API_URL });
api.interceptors.request.use(cfg => {
  const t = localStorage.getItem("access_token")
  if (t) cfg.headers.Authorization = `Bearer ${t}`;
  cfg.headers[`X-Tenant`] = localStorage.getItem(`tenent`) || `acme`;
  return cfg;
});