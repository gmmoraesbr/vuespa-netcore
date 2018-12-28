<template>
<div>
    <h2>{{ pageTitle }}</h2>
    <el-form v-loading="loading" :model="form" :rules="rules" ref="ruleForm">
      <el-form-item label="Solicitante da troca" prop="userRequestId">
        <el-select v-model="selectedRequest" filterable placeholder="Select">
          <el-option v-for="item in options" :key="item.userId" :label="item.name" :value="item.userId" ></el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="Dono da figurinha" prop="userOwnerId">
        <el-select :disabled="clickable" v-model="selectedOwner" filterable placeholder="Select">
          <el-option v-for="item in options" :key="item.userId" :label="item.name" :value="item.userId" ></el-option>
        </el-select>
      </el-form-item> 
      <el-form-item label="Número" prop="number">
        <el-input :disabled="clickable" v-model="form.number"></el-input>
      </el-form-item>
      <el-form-item label="Quantidade" prop="amount">
        <el-input :disabled="clickable" v-model="form.amount"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button @click="save" type="primary">Salvar</el-button>
      </el-form-item>
    </el-form>
</div>
</template>

<script>
export default {
  name: "FigureRequestExchange",
  data() {
    return {
      loading: false,
      form: {
        userOwnerId: 0,
        userRequestId: 0,
        name: null,
        email: null
      },
      options: [],
      selectedOwner: '',
      selectedRequest: ''
    };
  },
  computed: {
    pageTitle() {
      return `Solicitar troca do número`;
    },
    clickable() {
        return true;
    }
  },
  created() {
    let self = this;
    self.get(self.$route.params.id);
    self.getAll();
  },
  methods: {
    getAll() {
      let self = this;

      self.$store.state.services.userService
          .getAll()
          .then(r => {
              self.options = r.data;
          })
          .catch(r => {
              self.$message({
                  message: "Ocorreu um erro inesperado",
                  type: "error"
              });
          });
    },
    get(id) {
      if(id == undefined) return;

      let self = this;

      self.loading = true;
      self.$store.state.services.figureService
        .get(id)
        .then(r => {
          self.loading = false;
          self.form.figureId = r.data.figureId;
          self.form.number = r.data.number;
          self.form.amount = r.data.amount;
          self.selectedOwner = r.data.userId;
        })
        .catch(r => {
          self.$message({
            message: "Ocorreu um erro inesperado.",
            type: "error"
          });
        });
    },
    save() {
      let self = this;
      self.$refs["ruleForm"].validate(valid => {
        if (valid) {
          self.loading = true;
          
          self.form.userOwnerId = self.selectedOwner;
          self.form.userRequestId = self.selectedRequest;

            self.$store.state.services.figureUserService
              .add(self.form)
              .then(r => {
                self.loading = false;
                self.$router.push('/figures');
              })
              .catch(r => {
                self.$message({
                  message: "Ocorreu um errou inesperado.",
                  type: "error"
                });
              });
          }
      });
    }
  }
};
</script>