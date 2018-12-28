<template>
<div>
    <h2>{{ pageTitle }}</h2>
    <el-form v-loading="loading" :model="form" :rules="rules" ref="ruleForm">
      <el-form-item label="Nome" prop="name">
        <el-input v-model="form.name"></el-input>
      </el-form-item>
      <el-form-item label="E-mail" prop="email">
        <el-input v-model="form.email"></el-input>
      </el-form-item>
      <el-form-item label="Senha" prop="password">
        <el-input type="password" v-model="form.password" autocomplete="off"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button @click="save" type="primary">Salvar</el-button>
      </el-form-item>
    </el-form>
</div>
</template>

<script>
export default {
  name: "UserCreateOrUpdate",
  data() {
    return {
      loading: false,
      form: {
        userId: 0,
        name: null,
        email: null
      },
      rules: {
        name: [
          { required: true, message: "Você deve digitar um nome." },
          { min: 3, message: "Deve conter pelo menos 3 caracteres." }
        ],
        email: [{ required: true, message: "O e-mail é obrigatório." }],
        senha: [{ required: true, message: "O senha é obrigatório." }]
      },
      options: [],
      dafault: ''
    };
  },
  computed: {
    pageTitle() {
      return this.form.userId === 0 ? "Novo usuário" : `${this.form.name}`;
    }
  },
  created() {
    let self = this;
    self.get(self.$route.params.id);
  },
  methods: {
    get(id) {
      if(id == undefined) return;

      let self = this;

      self.loading = true;
      self.$store.state.services.userService
        .get(id)
        .then(r => {
          self.loading = false;
          self.form.userId = r.data.userId;
          self.form.name = r.data.name;
          self.form.email = r.data.email;
          self.form.password = r.data.password;
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

          if(self.form.userId > 0) {
            self.$store.state.services.userService
            .update(self.form)
            .then(r => {
              self.loading = false;
              self.$router.push('/users');
            })
            .catch(r => {
              self.$message({
                message: "Ocorreu um errou inesperado.",
                type: "error"
              });
            });
          } else {
            self.$store.state.services.userService
              .add(self.form)
              .then(r => {
                self.loading = false;
                self.$router.push('/users');
              })
              .catch(r => {
                self.$message({
                  message: "Ocorreu um errou inesperado.",
                  type: "error"
                });
              });
          }
        }
      });
    }
  }
};
</script>