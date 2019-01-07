<template>
<div>
    <h2>Figurinhas</h2>
    <el-table v-loading="loading" :data="data" style="width: 100%;">
        <el-table-column prop="number" label="Número da figurinha" sortable></el-table-column>
        <el-table-column prop="amount" label="Quantidade" sortable></el-table-column>
        <el-table-column prop="user.name" label="Usuário" sortable></el-table-column>
        <!-- <el-table-column prop="userId" label="Usuário" sortable></el-table-column> -->
        <el-table-column align="right">
            <template slot-scope="scope">
                <el-button type="success" @click="request(`${scope.row.figureId}`,`${scope.row.amount}`)">Solicitar trocar</el-button>
                <el-button type="danger" @click="remove(scope.row.figureId)">Deletar</el-button>
            </template>
        </el-table-column>    
    </el-table>
</div>
</template>

<script>
export default {
    name: "FigueIndex",
    data() {
        return {
            data: [],
            loading: false
        };
    },
    created() {
        let self = this;
        self.getAll();
    },
    methods: {
        request(figureId, amount){
            let self = this;

            if(amount <= 1){
                self.$message({
                    message: "Solicitação de troca somente com quantidade maior que 1.",
                    type: "error"
                });
            }else {
                self.$router.push(`/figures/${figureId}/request`)
            }
        },
        getAll() {
            let self = this;

            self.loading = true;

            self.$store.state.services.figureService
                .getAll()
                .then(r => {
                    self.loading = false;
                    self.data = r.data;
                })
                .catch(r => {
                    self.$message({
                        message: "Ocorreu um erro inesperado",
                        type: "error"
                    });
                });
        },
        remove(id){
            let self = this;

            self
                .$confirm("Está seguro de realizar esta ação?", "Confirmar", {
                    confirmButtonText: "Sim",
                    cancelButtonText: "Cancelar",
                    type: "warning"
                })
                .then(() => {
                    _remove();
                })
                .catch(() => {});

                function _remove() {
                    self.$store.state.services.figureService
                        .remove(id)
                        .then(r => {
                            self.loading = false;
                            self.getAll();
                        })
                        .catch(r => {
                            self.$message({
                                message: "Ocorreu um erro inesperado",
                                type: "error"
                            });
                        });
                }
        }
    }
};
</script>