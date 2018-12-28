<template>
<div>
    <h2>Figurinhas</h2>
    <el-table v-loading="loading" :data="data" style="width: 100%">
        <el-table-column prop="number" label="Número da figurinha" sortable></el-table-column>
        <el-table-column prop="userOwnerId" label="Dono" sortable></el-table-column>
        <el-table-column prop="userRequestId" label="Solicitante" sortable></el-table-column>
        <el-table-column prop="status" label="Status" sortable></el-table-column>
        <el-table-column align="right">
            <template slot-scope="scope">
                <el-button @click="aceitar(scope.row)">Aceitar</el-button>
                <el-button @click="recusar(scope.row)">Recusar</el-button>
            </template>
        </el-table-column>    
    </el-table>
</div>
</template>

<script>
export default {
    name: "FigueExchange",
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
        getAll() {
            let self = this;

            self.loading = true;

            self.$store.state.services.figureUserService
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
        aceitar(data){
            let self = this;

            if (data.status == 'Aceito') {
                self.$message({
                            message: "Você já aceitou a troca.",
                            type: "error"
                        });
            }else if (data.status == 'Recusado') {
                self.$message({
                            message: "Você já recusou a troca, não pode aceitar mais.",
                            type: "error"
                        });
            }else {
                data.status = 'Aceito';
                self.$store.state.services.figureUserService
                    .update(data)
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
        },
        recusar(data){
            let self = this;

            if (data.status == 'Aceito') {
                self.$message({
                            message: "Você já aceitou a troca, não pode recusar mais.",
                            type: "error"
                        });
            }else {
                data.status = 'Recusado';
                self.$store.state.services.figureUserService
                    .update(data)
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