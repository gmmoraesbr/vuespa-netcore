import Vue from 'vue'
import Router from 'vue-router'

import Default from '@/components/Default'
import StudentIndex from '@/components/students/Index'
import StudentCreateOrUpdate from '@/components/students/CreateOrUpdate'
import UserIndex from '@/components/users/Index'
import UserCreateOrUpdate from '@/components/users/CreateOrUpdate'

Vue.use(Router)

const routes = [
  { path: '/', name: 'Default', component: Default },
  { path: '/students/', name: 'StudentIndex', component: StudentIndex },
  { path: '/students/add', name: 'StudentCreate', component: StudentCreateOrUpdate },
  { path: '/students/:id/edit', name: 'StudentEdit', component: StudentCreateOrUpdate },
  { path: '/users/', name: 'UserIndex', component: UserIndex },
  { path: '/users/add', name: 'UserCreate', component: UserCreateOrUpdate },
  { path: '/users/:id/edit', name: 'UserEdit', component: UserCreateOrUpdate },
]

export default new Router({
  routes
})
