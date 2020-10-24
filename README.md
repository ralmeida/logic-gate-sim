# logic-gate-sim+

What if you could make your complex logic gates on a computer? Well there are plenty of tools out there and here is another one, with a slight twist. This tool will allow you to create Logic Gate [Boards](https://github.com/ralmeida/logic-gate-sim/tree/main/FPGA/Board) and add [Cells](https://github.com/ralmeida/logic-gate-sim/tree/main/FPGA/Cells) with designated [Gates](https://github.com/ralmeida/logic-gate-sim/tree/main/FPGA/Gates) and their connections. Gates Supported:
 [ OR - AND - NAND - NOT - NOR - XOR - XNOR ]
and each Cell can have;
- External Input(s)
- Internal Output(s)
- External Output(s)
- Setting for number of accepted incoming Inputs

Along with that is an attempt at a Genetic Algorithm to simulate random 'DNA' of a Logic Gate Board and evolve it to a working 4Bit Adder. So far in my experiments of a few weeks of running it was able to reach 80% on the tests. This was back in 2016/2017/2018 when I would work on it a bit more.

Over the next few weeks I hope to tighten up the code base and hopefully someone may find it useful! 

## Installation
Right now there is just the default installer and of course running it in Visual Studio.

## Usage
There are 2 main parts to the project
#### FPGA_Simulator
Simulator to build and test I/O manually or with a test script.

#### FPGA_DNAProcessor
GA Test Simulation that has a built-in 8Bit Adder test for ready usage.

## Basic Logic Gate Simulator
### FPGA_Simulator
{usage data to come}

## GA Test Simulation
### FPGA_DNAProcessor
{usage data to come}

## Contributing
Please submit any Pull Requests for review

## License
[MIT](https://choosealicense.com/licenses/mit/)