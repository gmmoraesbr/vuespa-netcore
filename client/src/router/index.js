import Vue from 'vue'
import Router from 'vue-router'

import Default from '@/components/Default'
import UserIndex from '@/components/users/Index'
import UserCreateOrUpdate from '@/components/users/CreateOrUpdate'
import FigureIndex from '@/components/figures/Index'
import FigureRequest from '@/components/figures/Request'
import FigureExchange from '@/components/figures/Exchange'
import FigureCreateOrUpdate from '@/components/figures/CreateOrUpdate'
import FigureRequestExchange from '@/components/figures/RequestExchange'

Vue.use(Router)

const routes = [
  { path: '/', name: 'Default', component: Default },
  { path: '/users/', name: 'UserIndex', component: UserIndex },
  { path: '/users/add', name: 'UserCreate', component: UserCreateOrUpdate },
  { path: '/users/:id/edit', name: 'UserEdit', component: UserCreateOrUpdate },
  { path: '/figures/', name: 'FigureIndex', component: FigureIndex },
  { path: '/figures/add', name: 'FigureCreate', component: FigureCreateOrUpdate },
  { path: '/figures/:id/edit', name: 'FigureEdit', component: FigureCreateOrUpdate },
  { path: '/figures/request', name: 'FigureRequest', component: FigureRequest },
  { path: '/figures/exchange', name: 'FigureExchange', component: FigureExchange },
  { path: '/figures/:id/request', name: 'FigureRequestExchange', component: FigureRequestExchange },
]

export default new Router({
  routes
})
