<template>
<el-container>
  <el-header style="background: rgb(4, 80, 160);">
    <h1><i class="fa fa-meh-o"></i> Figurinhas da Copa</h1>
  </el-header>
  <el-container>
    <el-aside style="width:240px;">
      <navegationmenu></navegationmenu>
    </el-aside>
    <el-container>
      <el-main>
        <el-row>
          <el-col :span="24">
            <router-view></router-view>
          </el-col>
        </el-row>
      </el-main>
      <!-- <el-footer>© <a target="_blank" href="{{ 'Gelson Moraes ' + new Date().getFullYear() }}</a></el-footer> -->
    </el-container>
  </el-container>
</el-container>
</template>

<script>
import navegationmenu from "@/components/shared/NavegationMenu";

export default {
  components: {
    navegationmenu
  },
  props: {
    source: String
  }
};
</script>