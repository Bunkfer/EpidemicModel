from typing import Protocol

class Main_model(Protocol):       

    def model_topdf(self)-> None: ...
        
    def show_model(self) -> None: ...

    def modelvsSim(self) -> None: ...
        