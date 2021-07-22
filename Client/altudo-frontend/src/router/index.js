import Vue from 'vue'
import VueRouter from 'vue-router'
import homeRoutes from '@/modules/home/router'  

Vue.use(VueRouter)

const routes = [
  ...homeRoutes,
    { path: '', redirect: '/home' }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
