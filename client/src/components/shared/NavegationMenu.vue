<template>
<el-menu default-active="0" style="background-color: #dce8f5;">
    <template v-for="item, i in items">
        <el-submenu :index="i.toString()" v-if="item.children !== undefined">
            <template slot="title">
                <i :class="'fa fa-' + item.icon"></i>
                <span>{{ item.text }}</span>
            </template>
            <el-menu-item-group title="Opções" style="background-color: #eff5fb;">
                <el-menu-item v-for="child, c in item.children" :index="(i.toString() + c)" @click="redirect(child.path)">
                    <i :class="'fa fa-' + child.icon"></i> <span>{{ child.text }}</span>
                </el-menu-item>
            </el-menu-item-group>    
        </el-submenu>
        <el-menu-item index="2" v-if="item.children === undefined" @click="redirect(item.path)">
            <i :class="'fa fa-' + item.icon"></i>
            <span>{{ item.text }}</span>
        </el-menu-item>
    </template>
</el-menu>
</template>

<script>
export default {
  name: "NavegationMenu",
  data: () => ({
    items: [
      //{ icon: "dashboard", text: "Dashboard", path: "/" },
      {
        icon: "table",
        text: "Figurinhas",
        children: [
          { icon: "plus", text: "Adicionar figurinhas", path: "/figures/add" },
          { icon: "list", text: "Listar figurinhas", path: "/figures" },
          { icon: "list", text: "Lista de solicitações", path: "/figures/request" },
          { icon: "list", text: "Ranking de trocas", path: "/figures/exchange" },
        ]
      },  
      {
        icon: "user",
        text: "Usuários",
        children: [
          { icon: "plus", text: "Adicionar usuários", path: "/users/add" },
          { icon: "list", text: "Listar usuários", path: "/users" },
        ]
      }
    ]
  }),
  methods: {
    redirect(path) {
      if(path === undefined) return;
      this.$router.push(path);
    }
  }
};
</script>