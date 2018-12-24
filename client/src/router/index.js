import Vue from 'vue'
import Router from 'vue-router'

import Default from '@/components/Default'
import UserIndex from '@/components/users/Index'
import UserCreateOrUpdate from '@/components/users/CreateOrUpdate'

Vue.use(Router)

const routes = [
  { path: '/', name: 'Default', component: Default },
  { path: '/users/', name: 'UserIndex', component: UserIndex },
  { path: '/users/add', name: 'UserCreate', component: UserCreateOrUpdate },
  { path: '/users/:id/edit', name: 'UserEdit', component: UserCreateOrUpdate },
]

export default new Router({
  routes
})
