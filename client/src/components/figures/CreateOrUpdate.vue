<template>
<div>
    <h2>{{ pageTitle }}</h2>
    <el-form v-loading="loading" :model="form" :rules="rules" ref="ruleForm">
      <el-form-item label="Dono" prop="userId">
        <el-select v-model="selected" filterable placeholder="Select">
          <el-option v-for="item in options" :key="item.userId" :label="item.name" :value="item.userId" ></el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="Número" prop="number">
        <el-input v-model="form.number"></el-input>
      </el-form-item>
      <el-form-item label="Quantidade" prop="amount">
        <el-input v-model="form.amount"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button @click="save" type="success">Salvar figurinha</el-button>
      </el-form-item>
    </el-form>
</div>
</template>

<script>
export default {
  name: "FigureCreateOrUpdate",
  data() {
    return {
      loading: false,
      form: {
        figureId: 0,
        number: null,
        amount: null,
        user: null
      },
      rules: {
        number: [{ required: true, message: "O número é obrigatório." }],
        amount: [{ required: true, message: "O quantidade é obrigatório." }]
      },
      options: [],
      selected: '',
    };
  },
  computed: {
    pageTitle() {
      return this.form.figureId === 0 ? "Nova figurinha" : `Número: ${this.form.number}`;
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
          self.selected = r.data.userId;
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

          if(self.form.fugureId > 0) {
            self.$store.state.services.figureService
            .update(self.form)
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
          } else {
            self.form.userid = self.selected;

            self.$store.state.services.figureService
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
        }
      });
    }
  }
};
</script>