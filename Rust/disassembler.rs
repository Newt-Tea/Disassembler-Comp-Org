#![allow(non_snake_case)]
use std::collections::HashMap;
use std::env;
use std::path::Path;
use std::fs::File;
use std::io::{BufRead, BufReader};
use std::io::Write;

/// How to run the code ///

//  1. Ensure that Rust is setup on your system
//  You need the rustc compiler
//      Run rustc --version to check

//      rustc --version Output
//          rustc 1.82.0 (f6e511eec 2024-10-15)


//  2. Go to the directory where your files are located
//  You can check if your files are there by running 'ls' in the terminal

//  3. Run the following
//  rustc ./disassembler.rs -o disassembler.out (this is compiling your program)
//  ./disassembler.out ./Add.hack (this is executing your program)

fn main()
{
    let args: Vec<String> = env::args().collect();

    // Check if appropriate file extension
    if args[1].contains(".hack")
    {
        // Check if file exists
        if Path::new(&args[1]).exists()
        {
            let mut file = File::open(&args[1]).unwrap();
            let Lines = BufReader::new(file);

            // Mutable Vector to be used for storing HACK instructions
            let mut hackList = Vec::<String>::new();

            // Computation HashMap
            let compTable = HashMap::from
            ([
                ("0101010", "0"),
                ("0111111", "1"),
                ("0111010", "-1"),
                ("0001100", "D"),
                ("0110000", "A"),
                ("1110000", "M"),
                ("0001101", "!D"),
                ("0110001", "!A"),
                ("1110001", "!M"),
                ("0001111", "-D"),
                ("0110011", "-A"),
                ("1110011", "-M"),
                ("0011111", "D+1"),
                ("0110111", "A+1"),
                ("1110111", "M+1"),
                ("0001110", "D-1"),
                ("0110010", "A-1"),
                ("1110010", "M-1"),
                ("0000010", "D+A"),
                ("1000010", "D+M"),
                ("0010011", "D-A"),
                ("1010011", "D-M"),
                ("0000111", "A-D"),
                ("1000111", "M-D"),
                ("0000000", "D&A"),
                ("1000000", "D&M"),
                ("0010101", "D|A"),
                ("1010101", "D|M")
            ]);

            // Destination HashMap
            let destTable = HashMap::from
            ([
                ("000", ""),
                ("001", "M="),
                ("010", "D="),
                ("011", "DM="),
                ("100", "A="),
                ("101", "AM="),
                ("110", "AD="),
                ("111", "ADM=")
            ]);

            // Jump HashMap
            let jumpTable = HashMap::from
            ([
                ("000", ""),
                ("001", ";JGT"),
                ("010", ";JEQ"),
                ("011", ";JGE"),
                ("100", ";JLT"),
                ("101", ";JNE"),
                ("110", ";JLE"),
                ("111", ";JMP")
            ]);


            // Loop through all assembly lines in the HACK file
            for line in Lines.lines() 
            {                
                // A Instruction
                // if - Check instruction op-code (the first char in the string)

                    // Get the remaining substring and convert to decimal 
                    // Conversion (just uncomment)
                    //      let value = isize::from_str_radix(&line[1..16], 2).unwrap();

                    // Construct the appropriate HACK instruction (I suggest format!)
                    // https://devenum.com/5-ways-to-concatenate-string-in-rust/

                    // Append to hackList
                    // https://doc.rust-lang.org/std/vec/struct.Vec.html

                // C Instruction
                // else if - Check instruction op-code (the first char in the string)

                    // Create strings from the appropriate substrings
                    // cBit, dBit, jBit
                    // https://docs.rs/substring/latest/substring/

                    // Return HACK destination string from destTable using dBit
                    // https://doc.rust-lang.org/std/collections/struct.HashMap.html

                    // Return HACK computation string from compTable using cBit

                    // Return HACK jump string from jumpTable using jBit

                    // Construct the appropriate HACK instruction

                    // Append to hackList
            }


            // Write to file
            file = File::create(args[1].replace(".hack", ".asm")).expect("Unable to create file");

            if let Err(e) = write!(file, "{}", hackList.join(""))
            {
                println!("Writing error: {}", e.to_string());
            }
        }
    }
}
