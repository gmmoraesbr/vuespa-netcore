<template>
<div>
    <h2>{{ pageTitle }}</h2>
    <el-form v-loading="loading" :model="form" :rules="rules" ref="ruleForm">
      <el-row>
        <el-col :span="12">
          <div class="grid-content bg-purple">
            <el-form-item label="Solicitante" prop="userRequestId">
              <el-select @change="selectFigureUser" v-model="selectedRequest" filterable placeholder="Select">
                <el-option v-for="item in options" :key="item.userId" :label="item.name" :value="item.userId" ></el-option>
              </el-select>
            </el-form-item>
          </div>
        </el-col>
        <el-col :span="12">
          <div class="grid-content bg-purple">
            <el-form-item label="Solicitado" prop="userOwnerId">
              <el-select :disabled="clickable" v-model="selectedOwner" filterable placeholder="Select">
                <el-option v-for="item in options" :key="item.userId" :label="item.name" :value="item.userId" ></el-option>
              </el-select>
            </el-form-item>
          </div>
        </el-col>
      </el-row>
      <el-row>
        <el-col :span="12">
          <div class="grid-content bg-purple">
            <el-form-item label="Número da figurinha" prop="figureRequestId">
              <el-select  @change="selectFigureNumber" v-model="selectedRequestFigure" filterable placeholder="Select">
                <el-option v-for="item in optionsNumber" :key="item.figureId" :label="item.number" :value="item.figureId" ></el-option>
              </el-select>
            </el-form-item>
          </div>
        </el-col>
        <el-col :span="12">
          <div class="grid-content bg-purple">
            <el-form-item label="Número da figurinha" prop="numberOwner">
              <el-input :disabled="clickable" v-model="form.numberOwner"></el-input>
            </el-form-item>
          </div>
        </el-col>
      </el-row>
      <el-form-item>
        <el-button @click="save" type="success">Solicitar troca</el-button>
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
        figureOwnerId: 0,
        figureRequestId: 0,
        numberRequest: null,
        numberOwner: null
      },
      options: [],
      optionsNumber: [],
      selectedOwner: '',
      selectedRequest: '',
      selectedRequestFigure: ''
    };
  },
  computed: {
    pageTitle() {
      return `Solicitar troca`;
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
          self.form.numberOwner = r.data.number;
          self.selectedOwner = r.data.userId;
        })
        .catch(r => {
          self.$message({
            message: "Ocorreu um erro inesperado.",
            type: "error"
          });
        });
    },
    selectFigureUser() {
      let self = this;

      self.selectedNumerRequest = null;

      self.$store.state.services.figureService
          .user(self.selectedRequest)
          .then(r => {
              self.optionsNumber = r.data;
          })
          .catch(r => {
              self.$message({
                  message: "Ocorreu um erro inesperado",
                  type: "error"
              });
          });
    },
    selectFigureNumber() {
      let self = this;

      self.$store.state.services.figureService
          .get(self.selectedRequestFigure)
          .then(r => {
              self.form.numberRequest = r.data.number;
          })
          .catch(r => {
              self.$message({
                  message: "Ocorreu um erro inesperado",
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
          self.form.figureOwnerId = self.form.figureId;
          self.form.figureRequestId = self.selectedRequestFigure;
          //debug;
          console.log(self.form);
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

<style>
  .el-row {
    margin-bottom: 20px;
    &:last-child {
      margin-bottom: 0;
    }
  }
  .el-col {
    border-radius: 4px;
  }
  .grid-content {
    border-radius: 4px;
    min-height: 36px;
  }
  .row-bg {
    padding: 10px 0;
    background-color: #f9fafc;
  }
</style>